using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            context.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            context.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });

            Student s1 = new Student { Id = 1, Name = "Егор", Surname = "Иванов" };
            Student s2 = new Student { Id = 2, Name = "Мария", Surname = "Васильева" };
            Student s3 = new Student { Id = 3, Name = "Олег", Surname = "Кузнецов" };
            Student s4 = new Student { Id = 4, Name = "Ольга", Surname = "Петрова" };

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);

            Course c1 = new Course
            {
                Id = 1,
                Name = "Операционные системы",
                Students = new List<Student> { s1, s2, s3 }
            };
            Course c2 = new Course
            {
                Id = 2,
                Name = "Алгоритмы и структуры данных",
                Students = new List<Student> { s2, s4 }
            };
            Course c3 = new Course
            {
                Id = 3,
                Name = "Основы HTML и CSS",
                Students = new List<Student> { s3, s4, s1 }
            };

            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);

            base.Seed(context);
        }
    }
}