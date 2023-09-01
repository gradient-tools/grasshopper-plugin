using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GradientTools
{
    public class GradientToolsInfo : GH_AssemblyInfo
    {
        public override string Name => "Gradient Tools";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => Properties.Resources.gradient;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("8282112a-cd13-4005-86fd-2f846e10b6e8");

        //Return a string identifying you or your company.
        public override string AuthorName => "Gradient Tools";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "devang@outlook.in";
    }
}