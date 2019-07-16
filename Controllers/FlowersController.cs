using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flowershop.Repositories;
using Flowershop.Models;

namespace Flowershop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FlowerController : ControllerBase
  {

    private readonly FlowerRepository _flr; //provides refrence to repository (service)


    public FlowerController(FlowerRepository flr)
    {
      _flr = flr;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Flower>> Get()
    {
      try
      {
        return Ok(_flr.GetAll());

      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      try
      {
        return Ok(_flr.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }


    }

    // POST api/values
    [HttpPost]
    public ActionResult<IEnumerable<Flower>> Post([FromBody] Flower value)
    {
      try
      {
        return Ok(_flr.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }

    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Flower> Put(int id, [FromBody] Flower value)
    {
      try
      {
        value.Id = id;
        return Ok(_flr.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
