using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Domain.Entities.Pos;
public class Page
{
    public string Id { get; set; }
    public string OrganizationId { get; set; }

    public int Order { get; set; }
    public string Name { get; set; }
}
