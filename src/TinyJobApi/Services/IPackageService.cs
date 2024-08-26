using System;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public interface IPackageService
{
    public Task<int> CreatePackageAsync(PackageDo packageDo);
    public Task<PackageDo?> GetPackageByIdAsync(int id);
    public Task<IEnumerable<PackageDo>> GetAllPackagesAsync();
    public Task<PackageDo?> UpdatePackageByIdAsync(int id, PackageDo packageDo);
    public Task DeletePackageByIdAsync(int id);
}
