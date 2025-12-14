namespace AssiT.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity(DateTime createdAt)
        {
            IsDeleted = false;
            this.CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
