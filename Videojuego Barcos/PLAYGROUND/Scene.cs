using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace PLAYGROUND
{
    public class Scene
    {
        public List<VElement> Elements { get; set; }
        public List<Plataforma> barquitos { get; set; }

        public List<PlaneSupport> planes { get; set; }
        public Scene()
        {
            Elements = new List<VElement>();
            barquitos = new List<Plataforma>();
            planes = new List<PlaneSupport>();
        }

        public void AddElement(VElement element)
        {
            Debug.WriteLine("added");
            Elements.Add(element);
        }

        public void AddBarquito(Plataforma plataforma)
        {
            barquitos.Add(plataforma);
        }

        public void AddPlane(PlaneSupport plane)
        {
            planes.Add(plane);
        }
        public void Clear()
        {
            Elements.Clear();
            barquitos.Clear();
            planes.Clear();
        }
        public void Render(Graphics g, Size size)
        { 
            for (int s = 0; s < Elements.Count; s++)
            {
                
                Elements[s].Render(g,size);
            }

            for(int i = 0; i < barquitos.Count; i++)
            {
                barquitos[i].Render(g,size);
               
            }

            for(int i = 0; i < planes.Count; i++ )
            {
                planes[i].Render(g,size);
            }
        }
    }
}
