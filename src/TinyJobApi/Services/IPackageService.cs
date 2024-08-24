using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services;

public interface IPackageService
{
    public Task<Package> CreatePackageAsync(Package package);
    public Task<Package?> GetPackageByIdAsync(int id);
    public Task<IEnumerable<Package>> GetAllPackagesAsync();
    public Task<Package?> UpdatePackageByIdAsync(int id, Package package);
    public Task DeletePackageByIdAsync(int id);

}
