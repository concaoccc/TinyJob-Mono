using System;
using TinyJobApi.Database;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public class PackageServiceImp(AppDbContext appDbContext) : IPackageService
{
    public PackageVo CreatePackage(PackageCreationVo packageCreationVo)
    {
        var packageDo = new PackageDo
        {
            Name = packageCreationVo.Name,
            Description = packageCreationVo.Description,
            RelativePath = packageCreationVo.RelativePath,
            StorageAccount = packageCreationVo.StorageAccount,
            Version = packageCreationVo.Version,
            CreateTime = DateTime.Now.ToUniversalTime(),
            UpdateTime = DateTime.Now.ToUniversalTime(),
        };
        appDbContext.Packages.Add(packageDo);
        appDbContext.SaveChanges();
        return ConvertPackageDoToVo(packageDo);
    }

    public void DeletePackageById(int id)
    {
        var package = appDbContext.Packages.FirstOrDefault(p => p.Id == id);
        if (package != null)
        {
            appDbContext.Packages.Remove(package);
            appDbContext.SaveChanges();
        }
    }

    public List<PackageVo> GetAllPackages()
    {
        var jobDos = appDbContext.Packages.ToList();
        return jobDos.Select(ConvertPackageDoToVo).ToList();
    }

    public PackageVo? GetPackageById(int id)
    {
        var jobDo = appDbContext.Packages.FirstOrDefault(p => p.Id == id);
        if (jobDo == null)
        {
            return null;
        }
        
        return ConvertPackageDoToVo(jobDo);
    }

    public PackageVo? UpdatePackageById(int id, PackageUpdateVo packageUpdateVo)
    {
        var existingPackage = appDbContext.Packages.FirstOrDefault(p => p.Id == id);
        if (existingPackage == null)
        {
            return null;
        }
        
        bool needUpdate = false;
        if (!string.IsNullOrEmpty(packageUpdateVo.Description) && packageUpdateVo.Description != existingPackage.Description)
        {
            needUpdate = true;
            existingPackage.Description = packageUpdateVo.Description;
        }

        if (!string.IsNullOrEmpty(packageUpdateVo.RelativePath) && packageUpdateVo.RelativePath != existingPackage.RelativePath)
        {
            needUpdate = true;
            existingPackage.RelativePath = packageUpdateVo.RelativePath;
        }
            
        if (!string.IsNullOrEmpty(packageUpdateVo.StorageAccount) && packageUpdateVo.StorageAccount != existingPackage.StorageAccount)
        {
            needUpdate = true;
            existingPackage.StorageAccount = packageUpdateVo.StorageAccount;
        }
            
        if (!string.IsNullOrEmpty(packageUpdateVo.Version) && packageUpdateVo.Version != existingPackage.Version)
        {
            needUpdate = true;
            existingPackage.Version = packageUpdateVo.Version;
        }

        if (!needUpdate)
        {
            return ConvertPackageDoToVo(existingPackage);
        }

        existingPackage.UpdateTime = DateTime.Now.ToUniversalTime();
        appDbContext.SaveChanges();

        return ConvertPackageDoToVo(existingPackage);
    }
    
    // convert PackageDo to PackageVo
    private PackageVo ConvertPackageDoToVo(PackageDo packageDo)
    {
        return new PackageVo
        {
            Id = packageDo.Id,
            Name = packageDo.Name,
            Description = packageDo.Description,
            RelativePath = packageDo.RelativePath,
            StorageAccount = packageDo.StorageAccount,
            Version = packageDo.Version,
            CreateTime = packageDo.CreateTime,
            UpdateTime = packageDo.UpdateTime,
        };
    }
}
