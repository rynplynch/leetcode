{
  description = "My answers to leetcode questions; learning TDD";
  inputs = {
    nixpkgs.url = "nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };
  outputs = {
    nixpkgs,
    flake-utils,
    ...
  }:
    flake-utils.lib.eachDefaultSystem (
      system: let
        pkgs = import nixpkgs {inherit system;};
        projectFile = "./leetcode/Leetcode.csproj";
        testProjectFile = "./leetcode.test/Leetcode.test.csproj";
        dotnet-sdk = pkgs.dotnetCorePackages.dotnet_10.sdk;
        dotnet-runtime = pkgs.dotnetCorePackages.dotnet_10.runtime;
        version = "0.0.1";
      in {
        packages = {
          default = pkgs.buildDotnetModule {
            inherit projectFile testProjectFile dotnet-sdk dotnet-runtime;
            pname = "rynplynch-leetcode";
            version = version;
            src = ./.;
            nugetDeps = ./nix/deps.nix; # run `nix build .#default.passthru.fetch-deps && ./result` and put the result here
            doCheck = true;
          };
        };
        devShells = {
          default = pkgs.mkShell {
            buildInputs = [dotnet-sdk];
          };
        };
      }
    );
}
