using System.ComponentModel.DataAnnotations;

namespace TorshiaWebApp.Models
{
    public abstract class BaseEntity<T>
    {
        [Key] 
        public T Id { get; set; }
    }
}
