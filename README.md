# SkyGameEngine

A comprehensive game engine for creating 2D and 3D games with a focus on performance and ease of use.

## Features

- **Cross-Platform**: Support for Windows, macOS, and Linux
- **Flexible Rendering**: Hardware-accelerated graphics with multiple rendering backends
- **Physics Engine**: Built-in 2D and 3D physics simulation
- **Asset Management**: Efficient asset loading and management system
- **Extensible Architecture**: Plugin system for custom components and systems
- **Scripting Support**: Multiple scripting language options
- **Editor Tools**: Integrated development environment for game creation


### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/USMCsky/SkyGameEngine.git
   cd SkyGameEngine
   ```

2. **Build the engine**
   ```bash
   mkdir build
   cd build
   cmake ..
   cmake --build .
   ```

3. **Install** (optional)
   ```bash
   cmake --install .
   ```

## Usage

### Basic Example

```cpp
#include <SkyEngine/Engine.h>

int main() {
    SkyEngine::Engine engine;
    
    if (!engine.initialize("My Game", 1280, 720)) {
        return -1;
    }
    
    while (engine.isRunning()) {
        engine.update();
        engine.render();
    }
    
    return 0;
}
```

### Creating Your First Game

1. Create a new project using the engine templates
2. Implement your game logic in your game classes
3. Use the built-in systems for rendering, physics, and input
4. Build and run your game

## Documentation

- **[API Reference](docs/api/)** - Detailed API documentation
- **[User Guide](docs/guide/)** - Step-by-step tutorials
- **[Architecture Overview](docs/architecture.md)** - Engine design and systems
- **[Examples](examples/)** - Sample projects and code snippets

## Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes and commit (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

Please review our [Contributing Guidelines](CONTRIBUTING.md) for more details.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

- **Issues**: Report bugs and request features on [GitHub Issues](https://github.com/USMCsky/SkyGameEngine/issues)
- **Discussions**: Join community discussions on [GitHub Discussions](https://github.com/USMCsky/SkyGameEngine/discussions)
- **Documentation**: Visit our [documentation site](docs/) for guides and tutorials

---

**Made with ❤️ by the SkyGameEngine team**
