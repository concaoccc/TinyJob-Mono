using System;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public interface IPackageService
{
    public PackageVo CreatePackage(PackageCreationVo packageCreationVo);
    public PackageVo? GetPackageById(int id);
    public PageVo<PackageVo> GetAllPackages(int page = 1, int size = 0);
    public PackageVo? UpdatePackageById(int id, PackageUpdateVo packageUpdateVo);
    public void DeletePackageById(int id);
}
