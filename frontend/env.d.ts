/// <reference types="vite/client" />

// List import.meta.env variables for type safety and autocomplete
interface ImportMetaEnv {
    readonly VITE_GRAPHQL_URI: string
}

// Describes import.meta itself — connects ImportMetaEnv to the env property on import.meta
interface ImportMeta {
    readonly env: ImportMetaEnv
}