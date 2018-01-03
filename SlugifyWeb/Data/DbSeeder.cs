using SlugifyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlugifyWeb.Data
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            var bloggOne = new Blogg { Title = "A blogg about programming" };
            context.Bloggs.Add(bloggOne);

            var bloggTwo = new Blogg { Title = "C#" };
            context.Bloggs.Add(bloggTwo);

            var bloggThree = new Blogg { Title = "Java Script" };
            context.Bloggs.Add(bloggThree);

            var coolPost = new Post { Blogg = bloggOne, Title = "Small CAPS@blah!" };
            context.Posts.Add(coolPost);

            context.SaveChanges();
        }
    }
}
