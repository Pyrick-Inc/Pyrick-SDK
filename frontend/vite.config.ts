import { defineConfig } from 'vite'
import { withBaseViteConfig } from '@pyrick-inc/vite-config'

export default withBaseViteConfig(
  defineConfig({
    build: { target: 'esnext' },
  })
)
