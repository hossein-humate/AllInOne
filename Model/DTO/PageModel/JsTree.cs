namespace Model.DTO.PageModel
{
    public class JsTree : BaseDto
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public JsTreeState state { get; set; }
        public string li_attr { get; set; }
        public string a_attr { get; set; }
        //public IList<JsTree> children { get; set; }
    }

    public class JsTreeState : BaseDto
    {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
        public bool Checked { get; set; }
    }
}
