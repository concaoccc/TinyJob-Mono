using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services.Mock;

public class MockPackageService : IPackageService
{
    private static readonly List<Package> packages = new ();

    public Task<Package> CreatePackageAsync(Package package)
    {
        packages.Add(package);
        return Task.FromResult(package);
    }

    public Task DeletePackageByIdAsync(int id)
    {
        var package = packages.FirstOrDefault(p => p.Id == id);
        if (package != null)
        {
            packages.Remove(package);
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Package>> GetAllPackagesAsync()
    {
        return Task.FromResult<IEnumerable<Package>>(packages);
    }

    public Task<Package?> GetPackageByIdAsync(int id)
    {
        return Task.FromResult(packages.FirstOrDefault(p => p.Id == id));
    }

    public Task<Package?> UpdatePackageByIdAsync(int id, Package package)
    {
        var existingPackage = packages.FirstOrDefault(p => p.Id == id);
        if (existingPackage != null)
        {
            existingPackage.Name = package.Name;
            existingPackage.Description = package.Description;
            existingPackage.RelativePath = package.RelativePath;
            existingPackage.StorageAccount = package.StorageAccount;
            existingPackage.Version = package.Version;
        }

        return Task.FromResult(existingPackage);
    }
}
