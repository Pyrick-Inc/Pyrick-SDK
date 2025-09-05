import React from 'react'
import { Outlet, createRootRoute } from '@tanstack/react-router'

export const Route = createRootRoute({
  component: () => (
    <div style={{ fontFamily: 'sans-serif', padding: 16 }}>
      <Outlet />
    </div>
  ),
})
