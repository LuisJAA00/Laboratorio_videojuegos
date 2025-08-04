using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    internal class Perspective
    {

        public Model PerspectiveModel(Model model)
        {
            Model resModel = model;
            resModel.transform = model.transform;

            for (int i = 0; i < resModel.mesh.triangles.Count; i++)
            {
                for (int j = 0; j < resModel.mesh.triangles[i].vertices.Count; j++)
                {
                    resModel.mesh.triangles[i].vertices[j] =model.mesh.triangles[i].vertices[j].PerspectiveMatrix(5);
                }
            }

            return resModel;
        }


    }
}
