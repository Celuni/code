C#
using NumSharp;
//from bitmap
var ndarray = bitmap.ToNDArray(flat: false, copy: false);
//ndarray.shape == (1, height, width, 3).
**To Bitmap:**
C#
//to bitmap
var bitmap_from_ndarray = ndarray.ToBitmap(width, height);
//or
var bitmap_from_ndarray = ndarray.ToBitmap(ndarray.shape[1], ndarray.shape[2]);
<br>
**Original Answer:**
The following method should do that.
 C#
public static NDArray GetBitmapBytes(Bitmap image)
{
    if (image == null) throw new ArgumentNullException(nameof(image));
    BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
    try
    {
        unsafe
        {
            //Create a 1d vector without filling it's values to zero (similar to np.empty)
            var nd = new NDArray(NPTypeCode.Byte, Shape.Vector(bmpData.Stride * image.Height), fillZeros: false);
            // Get the respective addresses
            byte* src = (byte*)bmpData.Scan0;
            byte* dst = (byte*)nd.Unsafe.Address; //we can use unsafe because we just allocated that array and we know for sure it is contagious.
            // Copy the RGB values into the array.
            Buffer.MemoryCopy(src, dst, nd.size, nd.size); //faster than Marshal.Copy
            return nd.reshape(1, image.Height, image.Width, 3);
        }
    }
    finally
    {
        image.UnlockBits(bmpData);
    }
}
