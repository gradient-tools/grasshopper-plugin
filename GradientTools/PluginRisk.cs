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
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public PluginRisk()
          : base("Plugin Risk", 
                "Plugin Risk",
                "Find out the unendorsed plugins used on this canvas",
                "Gradient Tools", 
                "Document")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Component Names", "Component names", "Component names", GH_ParamAccess.list);
            pManager.AddTextParameter("Category Names", "Category names", "Category names", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
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

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("cfc2d3d6-7028-4e71-b10a-e2b9cfa5aafd");
    }
}