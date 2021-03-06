        [...]
        // double angle = ...
        double cos_angle = cos(angle);
        double sin_angle = sin(angle);
        for (int i = 0; i < buffer.Width; i++)
        {
            for (int j = 0; j < buffer.Height; j++)
            {
                double val;
                double x;
                int c = 0;
                x = i * cos_angle - j * sin_angle;
                val = Math.Sin(inner * x);
                val += 1;
                val *= 128;
                val = val > 255 ? 255 : val;
                c = (int)val;
                Color col = Color.FromArgb(c, c, c);
                SetPixel(originalData, i, j, col);
 
                Data[i, j] = c;
            }
        }
        
