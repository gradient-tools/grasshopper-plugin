using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradientTools
{
    public class PluginRisk : GH_Component
    {
        public PluginRisk()
          : base("Plugin Risk", 
                "Plugin Risk",
                "Find out the unendorsed plugins used on this canvas",
                "Gradient Tools", 
                "Document")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Component Names", "Component names", "Component names", GH_ParamAccess.list);
            pManager.AddTextParameter("Category Names", "Category names", "Category names", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Document doc = Grasshopper.Instances.ActiveCanvas.Document;

            List<String> categories = new List<String>();
            List<String> components = new List<String>();

            if (doc != null)
            {
                foreach (IGH_Component component in doc.Objects.OfType<IGH_Component>())
                {
                    string componentName = component.NickName;
                    if (componentName != "Plugin Risk")
                    {
                        components.Add(componentName);
                        if (component.HasCategory)
                        {
                            string category = component.Category;
                            categories.Add(category);
                        }
                    }

                    
                    
                    
                }
            }

            DA.SetDataList("Component Names", components);
            DA.SetDataList("Category Names", categories);

        }

        protected override System.Drawing.Bitmap Icon => null;

        public override Guid ComponentGuid => new Guid("cfc2d3d6-7028-4e71-b10a-e2b9cfa5aafd");
    }
}