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
        // Add to Folders
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

        // Select from Folders
        public IQueryable SelectFromFolders()
        {
            using (var db = new MeLoModelContainer())
            {
                var query = from b in db.FoldersSet
                            select b;
                return query;
            }
        }

        // Delete from Folders
        public void DeleteFromFolders(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                var row = new FoldersSet { Id = id };
                db.FoldersSet.Remove(row);
                db.SaveChanges();
            }
        }

        //
        //
        //
        // Add to Settings
        public void AddTosettings(int id, string category, string extension, bool check)
        {
            using (var db = new MeLoModelContainer())
            {
                var setting = new SettingsSet
                {
                    Id = id,
                    Category = category,
                    Extension = extension,
                    Check = check
                };
                db.SettingsSet.Add(setting);
                db.SaveChanges();
            }
        }

        // Select from Settings
        public IQueryable SelectFromSettings(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                var query = from b in db.SettingsSet
                            select b;
                return query;
            }
        }

        // Delete from Settings
        public void DeleteFromSettings(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                var row = new SettingsSet { Id = id };
                db.SettingsSet.Remove(row);
                db.SaveChanges();
            }
        }
    }
}
