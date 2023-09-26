using System;

namespace BitoDesktop.Domain.Commons;

#pragma warning disable
public abstract class Auditable
{
    public string Id { get; set; }
}