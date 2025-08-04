using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    internal class Scale
    {

        public Model ScaleModel(Model model)
        {
            Model resModel = model;

            for(int i = 0; i < resModel.mesh.triangles.Count; i++)
            {
                for(int j = 0; j < resModel.mesh.triangles[i].vertices.Count; j++)
                {
                    resModel.mesh.triangles[i].vertices[j][0] = model.mesh.triangles[i].vertices[j][0]*model.transform.Scale;
                    resModel.mesh.triangles[i].vertices[j][1] = model.mesh.triangles[i].vertices[j][1] * model.transform.Scale;
                    resModel.mesh.triangles[i].vertices[j][2] = model.mesh.triangles[i].vertices[j][2] * model.transform.Scale;
                }
            }

            return resModel;
        }

    }
}
