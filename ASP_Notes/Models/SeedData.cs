using Microsoft.EntityFrameworkCore;

namespace ASP_Notes.Models
{
    public class SeedData
    {
        public static void SeedDatabase(NotesAPIDbContext context)
        {
             //context.Database.Migrate();

            if (context.Notes.Count() == 0)
            {

                context.Notes.AddRange(
                        new Note
                        {
                            Title = "JavaScript",
                            Text = "Изучение JavaScript - интересное и увлекательное занятие, которое позволяет развить и улучшить навыки программирования," +
                            " а также создавать с его помощью уникальные законченные проекты.Требуется лишь время для того, чтобы освоить JavaScript, а также постоянная практика.",
                            CreationDate = DateTime.Now
                        },
                        new Note
                        {
                            Title = "Тип данных",
                            Text = "JavaScript работает со следующими типами данных: null, undefined, String, Number, Boolean,  Object," +
                           " Array, Date, ReqExp, Error, Function.",
                            CreationDate = DateTime.Now
                        },
                        new Note
                        {
                            Title = "Инструкции",
                            Text = "Инструкция – выражение, в результате которого должны выполниться действия (например, объявление или инициализация переменной и т.д.).",
                            CreationDate = DateTime.Now
                        },
                        new Note
                        {
                            Title = "Объекты",
                            Text = "Любое значение в JavaScript, не являющееся строкой, числом, true, false, null или undefined, является объектом.",
                            CreationDate = DateTime.Now
                        },
                        new Note
                        {
                            Title = "Массивы",
                            Text = "Массивы – это упорядоченная коллекция значений.",
                            CreationDate = DateTime.Now
                        }
                        );
                context.SaveChanges();
            } 
        }                 

        }
    }