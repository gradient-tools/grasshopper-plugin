using System;
using System.Collections.Generic;
using Grasshopper.Kernel.Special;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino.UI;
using System.Drawing.Printing;
using System.Linq;
using Grasshopper.GUI.Canvas;

namespace GradientTools
{
    public class DeleteScribbles : GH_Component
    {

        public DeleteScribbles()
          : base(
                "Delete Scribbles",
                "Delete Scribbles",
                "Rid canvas of all the scribbles. You will not be able to go back if you perform this action.",
                "Gradient Tools", 
                "Document")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Clear", "Clear", "Attach a boolean toggle and set it to true", GH_ParamAccess.item);
       
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Get value of clear
            Boolean delete = false;
            DA.GetData("Clear", ref delete);

            // Get active document
            GH_Document doc = Grasshopper.Instances.ActiveCanvas.Document;
            
            // Get all the scribbles
            IEnumerable<GH_Scribble> scribbles = doc.Objects.OfType<GH_Scribble>();

            // Start a fresh list and add scribble objects to it
            List<GH_Scribble> delScribbles = new List<GH_Scribble>();
            foreach(GH_Scribble scribble in scribbles)
            {
                delScribbles.Add(scribble);
            }

            // Delete scribbles
            if (delete && delScribbles.Count>0)
            {

             doc.RemoveObjects(delScribbles, true);
      
            }


        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.delete_scribbles;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("FD98821D-5EB7-4023-8D43-5DE7B7603488"); }
        }
    }
}