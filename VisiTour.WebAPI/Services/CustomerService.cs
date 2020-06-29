using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.Exceptions;

namespace VisiTour.WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IB170172Context _context;
        private readonly IMapper _mapper;

        public CustomerService(IB170172Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public Model.Customers Autentifikacija(string username, string pass)
        {
            Database.Customers user = _context.Customers.Include(x => x.Role).FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, pass);
                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<Model.Customers>(user);
                }
            }
            return null;
        }

        public List<Model.Customers> Get([FromQuery]CustomerSearchRequest request)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                query = query.Where(x => x.Username.StartsWith(request.Username));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Customers>>(query);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt,string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            byte[] inArray = alg.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Customers Insert(CustomersUpsertRequest request)
        {
            var e = _mapper.Map<Customers>(request);

            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException("Passwords are incorrect!");
            }

            e.PasswordSalt = GenerateSalt();
            e.PasswordHash = GenerateHash(e.PasswordSalt, request.Password);

            _context.Customers.Add(e);

            _context.SaveChanges();

            return _mapper.Map<Model.Customers>(e);
        }


        public Model.Customers Update(int id, CustomersUpsertRequest request)
        {
            var e = _context.Set<Customers>().Find(id);
            _context.Set<Customers>().Attach(e);
            _context.Set<Customers>().Update(e);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.ConfirmPassword)
                {
                    throw new UserException("Passwords are incorrect!");
                }
                e.PasswordSalt = GenerateSalt();
                e.PasswordHash = GenerateHash(e.PasswordSalt, request.Password);
            }
            _mapper.Map(request, e);

            _context.SaveChanges();

            return _mapper.Map<Model.Customers>(e);
        }

        public Model.Customers GetById(int id)
        {
            var e = _context.Set<Customers>().Find(id);
            return _mapper.Map<Model.Customers>(e);
        }

        public Model.Customers Delete(int id)
        {
            var e = _context.Set<Customers>().Find(id);
            if (e == null)
            {
                throw new ArgumentNullException();
            }
            var fresh = e;
            _context.Set<Customers>().Remove(e);
            _context.SaveChanges();
            return _mapper.Map<Model.Customers>(fresh);
        }
    }
}
