using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Domain.Entities.Finance;
public class Currency
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public List<Value> Values { get; set; }

    [Required]
    public string Side { get; set; }

    [Required]
    public bool IsMain { get; set; }

    public string Symbol { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public class Value
    {
        [Required]
        public string ToCurrencyId { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
