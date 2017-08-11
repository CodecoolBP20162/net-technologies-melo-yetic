using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yetic_MeLo.Models;

namespace Yetic_MeLo
{
    class EntityManager
    {
        public void AddToFolders(int id, string path, bool music, bool pics, bool video)
        {
            using (var db = new MeLoModelContainer())
            {
                var folder = new FoldersSet
                {
                    Id = id,
                    Path = path,
                    Music = music,
                    Picture = pics,
                    Video = video
                };
                db.FoldersSet.Add(folder);
                db.SaveChanges();                
            }
        }

        public void SelectFromFolders()
        {
            using (var db = new MeLoModelContainer())
            {
                var query = from b in db.FoldersSet
                            select b;
            }
        }

        public void DeleteFromFoldersTable(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                var row = new FoldersSet { Id = id };
                db.FoldersSet.Remove(row);
                db.SaveChanges();
            }
        }

        ///
        public void AddTosettings(int id, string path, bool music, bool pics, bool video)
        {
            using (var db = new MeLoModelContainer())
            {
                var folder = new FoldersSet
                {
                    Id = id,
                    Path = path,
                    Music = music,
                    Picture = pics,
                    Video = video
                };
                db.FoldersSet.Add(folder);
                db.SaveChanges();
            }
        }
    }
}
