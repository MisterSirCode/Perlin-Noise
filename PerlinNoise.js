class PerlinNoise {
    constructor(seed) {
        this.seed = seed;
    }
    
    InitPerlinNoise(x, p, n) {
        let total = 0;
        let frequency;
        let amplitude;
        
        for(let i = 0; i < n + 1; ++i) {
            frequency = Math.pow(2, i);
            amplitude = Math.pow(p, i);
            total = total + this.InterpolateNoise(x * frequency) * amplitude;
        }

        return total;
    }

    InterpolateNoise(x) {
        let ix = x;
        let fx = x - ix;
        let v1 = this.SmoothNoise(ix);
        let v2 = this.SmoothNoise(ix + 1);
        return this.Interpolate(v1, v2, fx);
    }

    SmoothNoise(x) {
        return this.Noise(x) / 2 + this.Noise(x - 1) / 4 + this.Noise(x + 1) / 4;
    }
    
    Noise(x) {
        x = this.seed ^ x;
        return (1.0 - ((x * (x * x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0);
    }
    
    Interpolate(a, b, x) {
        let ft = x * Math.PI;
        let f = (1 - Math.cos(ft)) / 2;
        return a * (1 - f) + b * f;
    }
}