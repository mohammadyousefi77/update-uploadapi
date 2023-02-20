using Azure;
using FileUpload.Controllers;
using FileUpload.Data;
using FileUpload.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Services
{
    public class MO : IMoshakhasat
    {
        private readonly DbContextClass _dbContextClass;


        public MO(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public void Delete(long id)
        {
         var per=_dbContextClass.moshakhsats.Where(n=>n.ID==id).SingleOrDefault() ;

            _dbContextClass.moshakhsats.Remove(per);

            _dbContextClass.SaveChanges();
        }

        public async Task<List<Moshakhsat>> Get()
        {
            //res = _dbContextClass.moshakhsats.ToList();
            return await _dbContextClass.moshakhsats.ToListAsync();
        }

        public async Task<Moshakhsat> GetSingle(long id)
        {
            return await _dbContextClass.moshakhsats.Where(n => n.ID == id).SingleOrDefaultAsync();


        }

        public async Task post(Moshakhsat fileData)
        {

            _dbContextClass.moshakhsats.Add(fileData);
            _dbContextClass.SaveChanges();
        }

      

        public async Task<Moshakhsat> Put(long id, Moshakhsat mo)
        {

            //var existingStudent = await _dbContextClass.moshakhsats.Where(s => s.ID == id)
            //                                        .FirstOrDefaultAsync();
        
            var existingStudent2 = await GetSingle(id);


            if (existingStudent2 != null)
            {

                existingStudent2.Name = mo.Name;
                existingStudent2.LName = mo.LName;

                _dbContextClass.SaveChanges();

            }

            return existingStudent2;
            
        }
    }
}