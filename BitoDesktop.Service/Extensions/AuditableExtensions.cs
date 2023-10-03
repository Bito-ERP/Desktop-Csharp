using BitoDesktop.Domain.Commons;
using System;

namespace BitoDesktop.Service.Extensions;

public static class AuditableExtensions
{
    public static void Update(this Auditable auditable)
    {
       // auditable.UpdatedAt = DateTime.UtcNow;
    }
}