# Perlin-Noise
Multi-Language Perlin Noise class transcribed from this Java-based class [kuroppoi/brainwine (PerlinNoise.java)](https://github.com/kuroppoi/brainwine/blob/master/gameserver/src/main/java/brainwine/gameserver/zone/gen/PerlinNoise.java)

Credit to Kuroppoi for adding seed support to the class, based upon the ORIGINAL-original class [raxod502/TerrariaClone (PerlinNoise.java)](https://github.com/raxod502/TerrariaClone/blob/master/src/PerlinNoise.java)

Current Versions:

- Java - [PerlinNoise.java](./PerlinNoise.java)
- C# / Unity - [PerlinNoise.cs](./PerlinNoise.cs)
- Javascript - [PerlinNoise.js](./PerlinNoise.js)
- Lua - WORK IN PROGRESS

Both the Java and C# versions have been tested and are working. The javascript version is untested. Post any bugs / errors in the [Issues](https://github.com/MisterSirCode/Perlin-Noise/issues) tab.

### How do I use it? (C#, but can be transcribed to any above languages that are supported)

Initialize the class using a constructor in whichever language youre using it with:

```cs
PerlinNoise generator = new PerlinNoise((long)generationSeed);

// Be sure to feed it a seed. Any random Long integer will work.
```

Then feed it a current X position and the Perlin Settings to get a "height" which you can use for 1-dimensional heightmaps:

```cs
double perlinScale = 0.01;
double lacunarity = 0.5;
double worldScaler = 0.2 * 40.0 + (80.0 - 40.0);
int octaveWidth = 7;
int surfaceLevel = 10;

int noiseHeight = (int)(generator.InitPerlinNoise(x * perlinScale, lacunarity, octaveWidth) * worldScaler) + surfaceLevel; 
```
