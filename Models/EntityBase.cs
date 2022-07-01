namespace Web.Models
{
    public enum RowState
    {
        Normal, Add, Edit, Delete
    }
    public abstract class EntityBase
    {
        public uint? RowVersion { get; set; }
        public RowState RowState { get; set; }

        public EntityBase()
        {
            this.RowState = RowState.Normal;
        }
    }
}
