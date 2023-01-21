using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;

namespace Data.DataBase
{
    public class DbInitializer
    {

        public static void Initialize(AssessmentProjectDbContext context)
        {
            context.Database.EnsureCreated();


            //seed Term
            if (!context.Terms.Any())
            {
                var terms = new Term[]
                {
                    new Term{
                       Name ="Term1"
                    },
                    new Term{
                       Name ="Term2"
                    }
                };

                foreach (var t in terms)
                {
                    context.Terms.Add(t);
                    context.SaveChanges();

                }

                context.SaveChanges();
            }

            //seed Subjects
            if (!context.Subjects.Any())
            {
                var subjects = new Subject[]
                {
                    new Subject{
                       Name ="Subject1"
                    },
                    new Subject{
                       Name ="Subject2"
                    }
                };

                foreach (var s in subjects)
                {
                    context.Subjects.Add(s);
                    context.SaveChanges();

                }

                context.SaveChanges();
            }

            // seed Student
            if (!context.students.Any())
            {
                var students = new Student[]
                {
                    new Student{
                        Name = "student 1",
                        Gender = GenderType.Male.ToString(),
                        Email = "a@b.com",
                        Mobile = "0123456789",
                        DOB = System.DateTime.Now,
                        CurrentTermID = 1,
                        Parents = new Parent[]{
                         new Parent{
                            Name = "Parent 1",
                            Type = ParentType.Father.ToString(),
                            Email = "a@b.com",
                            Mobile = "0123456789"
                         },
                          new Parent{
                            Name = "Parent 2",
                            Type = ParentType.Mother.ToString(),
                            Email = "a@b.com",
                            Mobile = "0123456789"
                         }
                        }
                    },
                  new Student{
                        Name = "student 2",
                        Gender = GenderType.Male.ToString(),
                        Email = "a@b.com",
                        Mobile = "0123456789",
                        DOB = System.DateTime.Now,
                        CurrentTermID = 1,
                        Parents = new Parent[]{
                         new Parent{
                            Name = "Parent 3",
                            Type = ParentType.Father.ToString(),
                            Email = "a@b.com",
                            Mobile = "0123456789"
                         },
                          new Parent{
                            Name = "Parent 4",
                            Type = ParentType.Mother.ToString(),
                            Email = "a@b.com",
                            Mobile = "0123456789"
                         }
                        }
                    }
                };

                foreach (var sub in students)
                {
                    context.students.Add(sub);
                }

                context.SaveChanges();
            }

            //seed Marks
            if (!context.Marks.Any())
            {
                var marks = new Marks[]
                {
                    new Marks{
                       StudentId = 1,
                       TermId = 1,
                       SubjectId = 1,
                       //StudyYear = System.DateTime.Now.ToString(),
                       StudyYear = StudyYears.y2022.ToString(),
                       IsAbsent = false,
                       Mark = 80
                    },
                    new Marks{
                       StudentId = 1,
                       TermId = 1,
                       SubjectId = 1,
                       StudyYear = StudyYears.y2022.ToString(),
                       IsAbsent = false,
                       Mark = 70
                    }
                };

                foreach (var m in marks)
                {
                    context.Marks.Add(m);
                    context.SaveChanges();

                }

                context.SaveChanges();
            }


        }

    }
}
