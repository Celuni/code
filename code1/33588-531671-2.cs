    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.ComponentModel;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public class Student
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public IList<int> Courses { get; set; }
                public static implicit operator Student(StudentDTO studentDTO)
                {
                    return PropertyCopy<Student>.CopyFrom(studentDTO);
                }
            }
    
            public class StudentDTO
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public IList<int> Courses { get; set; }
                public static implicit operator StudentDTO(Student student)
                {
                    return PropertyCopy<StudentDTO>.CopyFrom(student);
                }
            }
    
    
            static void Main(string[] args)
            {
                Student _student = new Student();
                _student.Id = 1;
                _student.Name = "Timmmmmmmmaaaahhhh";
                _student.Courses = new List<int>();
                _student.Courses.Add(101);
                _student.Courses.Add(121);
    
                StudentDTO itemT = _student;
    
                Console.WriteLine(itemT.Id);
                Console.WriteLine(itemT.Name);
                Console.WriteLine(itemT.Courses.Count);
            }
    
    
        }
    
    
        // COOLEST PIECE OF CODE FROM - http://www.yoda.arachsys.com/csharp/miscutil/
    
        /// <summary>
        /// Generic class which copies to its target type from a source
        /// type specified in the Copy method. The types are specified
        /// separately to take advantage of type inference on generic
        /// method arguments.
        /// </summary>
        public class PropertyCopy<TTarget> where TTarget : class, new()
        {
            /// <summary>
            /// Copies all readable properties from the source to a new instance
            /// of TTarget.
            /// </summary>
            public static TTarget CopyFrom<TSource>(TSource source) where TSource : class
            {
                return PropertyCopier<TSource>.Copy(source);
            }
    
            /// <summary>
            /// Static class to efficiently store the compiled delegate which can
            /// do the copying. We need a bit of work to ensure that exceptions are
            /// appropriately propagated, as the exception is generated at type initialization
            /// time, but we wish it to be thrown as an ArgumentException.
            /// </summary>
            private static class PropertyCopier<TSource> where TSource : class
            {
                private static readonly Func<TSource, TTarget> copier;
                private static readonly Exception initializationException;
    
                internal static TTarget Copy(TSource source)
                {
                    if (initializationException != null)
                    {
                        throw initializationException;
                    }
                    if (source == null)
                    {
                        throw new ArgumentNullException("source");
                    }
                    return copier(source);
                }
    
                static PropertyCopier()
                {
                    try
                    {
                        copier = BuildCopier();
                        initializationException = null;
                    }
                    catch (Exception e)
                    {
                        copier = null;
                        initializationException = e;
                    }
                }
    
                private static Func<TSource, TTarget> BuildCopier()
                {
                    ParameterExpression sourceParameter = Expression.Parameter(typeof(TSource), "source");
                    var bindings = new List<MemberBinding>();
                    foreach (PropertyInfo sourceProperty in typeof(TSource).GetProperties())
                    {
                        if (!sourceProperty.CanRead)
                        {
                            continue;
                        }
                        PropertyInfo targetProperty = typeof(TTarget).GetProperty(sourceProperty.Name);
                        if (targetProperty == null)
                        {
                            throw new ArgumentException("Property " + sourceProperty.Name + " is not present and accessible in " + typeof(TTarget).FullName);
                        }
                        if (!targetProperty.CanWrite)
                        {
                            throw new ArgumentException("Property " + sourceProperty.Name + " is not writable in " + typeof(TTarget).FullName);
                        }
                        if (!targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            throw new ArgumentException("Property " + sourceProperty.Name + " has an incompatible type in " + typeof(TTarget).FullName);
                        }
                        bindings.Add(Expression.Bind(targetProperty, Expression.Property(sourceParameter, sourceProperty)));
                    }
                    Expression initializer = Expression.MemberInit(Expression.New(typeof(TTarget)), bindings);
                    return Expression.Lambda<Func<TSource,TTarget>>(initializer, sourceParameter).Compile();
                }
            }
        }
    
    }
