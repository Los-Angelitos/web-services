using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates
{
    public partial class Notification : IEntityWithCreatedUpdatedDate
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}