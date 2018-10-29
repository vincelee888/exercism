module SpaceAge

[<Measure>]
type EarthDay

type Planet = {
  OrbitalPeriod: float<EarthDay>
}

let Earth = { OrbitalPeriod = 365.25<EarthDay> }
let Mercury = { OrbitalPeriod = 0.2408467 * Earth.OrbitalPeriod }
let Venus = { OrbitalPeriod = 0.61519726 * Earth.OrbitalPeriod }
let Mars = { OrbitalPeriod = 1.8808158 * Earth.OrbitalPeriod }
let Jupiter = { OrbitalPeriod = 11.862615 * Earth.OrbitalPeriod }
let Saturn = { OrbitalPeriod = 29.447498 * Earth.OrbitalPeriod }
let Uranus = { OrbitalPeriod = 84.016846 * Earth.OrbitalPeriod }
let Neptune = { OrbitalPeriod = 164.79132 * Earth.OrbitalPeriod }

let getOrbitalPeriodInSecs(orbitalPeriod:float<EarthDay>) : float = 
  float orbitalPeriod * 24.0 * 60.0 * 60.0

let age (planet: Planet) (seconds: int64): float = 
  (float seconds) / (getOrbitalPeriodInSecs planet.OrbitalPeriod)