import type { Config } from 'tailwindcss'
import preset from '@pyrick-inc/frontend-config/tailwind.preset.cjs'

export default {
  presets: [preset],
  content: ['./index.html', './src/**/*.{ts,tsx,js,jsx}'],
} satisfies Config
