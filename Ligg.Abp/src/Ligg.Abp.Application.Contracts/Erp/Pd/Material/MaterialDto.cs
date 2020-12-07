using System;

namespace Ligg.Abp.Application.Contracts
{
    public class MaterialDto 
    {
        public int Type { get; set; }

        public long No { get; set; }

        public Guid NameId { get; set; }


        public String Specification { get; set; }


        public String OtherAttribute { get; set; }


        public String Stuff { get; set; }


        public String DrawingCode { get; set; }


        public Guid BasicUnitId { get; set; }

    }


}