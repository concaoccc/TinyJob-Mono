using System;

namespace TinyJobApi.Models.Vo;

public class JobUpdateVo
{
    public long Id { get; set; }
    public required string Status { get; set; }
}
