using FileUpload.Data;
using FileUpload.Entities;
using FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moshakhasat2 : ControllerBase
    {
        private readonly IMoshakhasat _moshakhasat;

      
        public moshakhasat2(IMoshakhasat moshakhasa) {
            _moshakhasat= moshakhasa;
           
        }


        [HttpPost("PostSinglerecord")]
        public async Task<ActionResult<Moshakhsat>> PostSingl([FromForm] Moshakhsat mo)
        {
            if (mo == null)
            {
                return Problem("Entity set 'MoshakhasatContext.student'  is null.");
            }

            await _moshakhasat.post(mo);

           
             return Ok();
        }

        [HttpGet("Geterecord")]
        public async Task<ActionResult<List<Moshakhsat>>> GetSingl()
        {
            //   var f = _moshakhasat.Get();
            // await _moshakhasat.Get();    

            return await  _moshakhasat.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Moshakhsat>> GetBy(long id )
        {
            var person = await _moshakhasat.GetSingle(id);
            if (person== null)
            {
                return NotFound();
            }
          //  var student = await _context.student.FindAsync(id);

       

            return person;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Moshakhsat>> PutBy(long id ,Moshakhsat mo)
        {
            var person = await _moshakhasat.Put(id,mo);
            if (person == null)
            {
                return NotFound();
            }
            //  var student = await _context.student.FindAsync(id);



            return person;
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            _moshakhasat.Delete(id);    
            return Ok();
        }

    }
}
