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
        // Folders //
        // Add
        public void AddToFolders(string path, bool music, bool pics, bool video)
        {
            using (var db = new MeLoModelContainer())
            {
                var folder = new FoldersSet
                {
                    Path = path,
                    Music = music,
                    Picture = pics,
                    Video = video
                };
                db.FoldersSet.Add(folder);
                db.SaveChanges();                
            }
        }

        // Select
        public IQueryable SelectFromFolders(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                if(id != 0)
                {
                    var query = from b in db.FoldersSet
                                where b.Id == id
                                select b;
                    return query;
                }
                else
                {
                    throw new Exception("There is no entity with the given Id: " + id);
                }
            }
        }

        // Update
        public void UpdateFromFolders(int id, string newPath, bool newMusic, bool newPicture, bool newVideo)
        {
            using (var db = new MeLoModelContainer())
            {
                var rowToUpdate = db.FoldersSet.Find(id);
                rowToUpdate.Path = newPath;
                rowToUpdate.Music = newMusic;
                rowToUpdate.Picture = newPicture;
                rowToUpdate.Video = newVideo;
                db.SaveChanges();
            }
        }

        // Delete 
        public void DeleteFromFolders(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                if(db.FoldersSet.Find(id) != null)
                {
                    var row = db.FoldersSet.Find(id);
                    db.FoldersSet.Remove(row);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("There is no entity with the given Id: " + id);
                }
               
            }
        }

        // Settings //
        // Add
        public void AddTosettings(string category, string extension, bool check)
        {
            using (var db = new MeLoModelContainer())
            {
                var setting = new SettingsSet
                {
                    Category = category,
                    Extension = extension,
                    Check = check
                };
                db.SettingsSet.Add(setting);
                db.SaveChanges();
            }
        }

        // Select 
        public IQueryable SelectFromSettings(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                if (id != 0)
                {
                    var query = from b in db.SettingsSet
                                where b.Id == id
                                select b;
                    return query;
                }
                else
                {
                    throw new Exception("There is no entity with the given Id: " + id);
                }
            }
        }

        // Update
        public void UpdateFromSettings(int id, string newCategory, string newExtension, bool newCheck)
        {
            using (var db = new MeLoModelContainer())
            {
                var rowToUpdate = db.SettingsSet.Find(id);
                rowToUpdate.Category = newCategory;
                rowToUpdate.Extension = newExtension;
                rowToUpdate.Check = newCheck;
                db.SaveChanges();
            }
        }

        // Delete 
        public void DeleteFromSettings(int id)
        {
            using (var db = new MeLoModelContainer())
            {
                if (db.SettingsSet.Find(id) != null)
                {
                    var row = db.SettingsSet.Find(id);
                    db.SettingsSet.Remove(row);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("There is no entity with the given Id: " + id);
                }

            }
        }
    }
}
