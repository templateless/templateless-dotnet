# CHANGELOG

## v0.2.0:

### New Features
- New social icons: `Service.Mastodon` and `Service.Rss`
- New `StoreBadges` component
- New `QrCode` component
- New `Signature` component
- New [examples](examples)

### Enhancements
- Only `src` is required for the `Image` component, all other params are optional
- Text for `ViewInBrowser` component is optional now
- Updated README & NUGET-README
- Dependency updates

## v0.1.5:
- `README.md`
  - markdown supports ordered/unordered lists
  - notice about test mode
- Support for test mode logging

## v0.1.4:
- `README.md` cleanup (listing of components)
- `Image` component now requires only `src`; the other params are optional
- `ViewInBrowser` component has changed: text is optional
- `coverlet.collector` upgrade

## v0.1.3:
- Introduced new services as [social icons](examples/VerificationExample/Program.cs):
  - `Service.Phone` (converts into a link with `tel:` prefix)
  - `Service.Facebook`
  - `Service.YouTube`
  - `Service.Instagram`
  - `Service.LinkedIn`
  - `Service.Slack`
  - `Service.Discord`
  - `Service.TikTok`
  - `Service.Snapchat`
  - `Service.Threads`
  - `Service.Telegram`

## v0.1.2:
- Introduced `CHANGELOG.md`
- Added `icon.png` to `PackageIcon`
- Minor example adjustments
- Minor `README.md` cleanup

## *v0.1.1:
- Initial implementation