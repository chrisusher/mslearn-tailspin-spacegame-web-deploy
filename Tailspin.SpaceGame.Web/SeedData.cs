using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TailSpin.SpaceGame.Web.DB;
using TailSpin.SpaceGame.Web.Models;

namespace TailSpin.SpaceGame.Web
{
    public static class SeedData
    {
        internal static void Initialize(TailspinContext db)
        {
            var profiles = JsonSerializer.Deserialize<List<Profile>>(File.ReadAllText(@"SampleData/profiles.json"));

            db.Profiles.AddRange(profiles);
            db.SaveChanges();

            var scores = JsonSerializer.Deserialize<List<Score>>(File.ReadAllText(@"SampleData/scores.json"));

            db.Scores.AddRange(scores);
            db.SaveChanges();
        }
    }
}