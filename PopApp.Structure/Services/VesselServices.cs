﻿using Microsoft.EntityFrameworkCore;
using PopApp.Core.Entities;
using PopApp.Core.Interfaces.Services;
using PopApp.Structure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PopApp.Structure.Services
{
    public class VesselServices : IVesselServices
    {
        private readonly PopAppContext _context;

        public VesselServices(PopAppContext context)
        {
            _context = context;
        }
        public async Task CreatetVessel(Vessel vessel)
        {
            _context.Add(vessel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVessel(int id)
        {
            var vessel = await GetVessel(id);

            if (vessel != null)
            {
                vessel.IsActive = false;
                _context.Update(vessel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Vessel> GetVessel(int id)
        {
            var vessel = await _context.Vessels.FirstOrDefaultAsync(opt => opt.VesselId == id);
            return vessel;
        }

        public async Task<IEnumerable<Vessel>> GetVessels()
        {
            var vessel = await _context.Vessels.ToListAsync();
            return vessel;
        }

        public async Task UpdateVessel(int id, Vessel vessel)
        {
            var updateVessel = await GetVessel(id);
            if (updateVessel != null)
            {
                updateVessel.VesselName = vessel.VesselName;
                updateVessel.VesselCode = vessel.VesselCode;
                updateVessel.VesselFlag = vessel.VesselFlag;
                updateVessel.VesselImo = vessel.VesselImo;
                updateVessel.VesselSlora = vessel.VesselSlora;
                updateVessel.VesselArrival = vessel.VesselArrival;
                updateVessel.IsActive = true;

                _context.Update(updateVessel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
