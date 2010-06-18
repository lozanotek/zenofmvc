namespace MVCDemo2.Controllers {
    using System;

    [Serializable]
    public class TableInputModel {
        public string Sidx { get; set; }
        public string Sord { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }
        public bool NotPaged { get; set; }
    }
}