using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    internal class Scene
    {
        public List<Model> models;
        public String path2file;
        public Scene(string path2file) { 
            models = new List<Model>();
            this.path2file = path2file;
            models.Add(new Model(path2file));
        }
    }
}
