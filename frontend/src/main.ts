import { createApp, provide, h } from 'vue'
import { createPinia } from 'pinia'
import { DefaultApolloClient } from '@vue/apollo-composable'
import { apolloClient } from './apollo'
import './assets/style.scss'

import App from './App.vue'
import router from './router'

/*
 * Component options object is used instead of createApp(App) directly,
 * so provide() can be called at the app root level — making the Apollo client
 * available to all components via useQuery() and useMutation().
 *
 * h() is Vue's hyperscript function — it creates a virtual DOM node.
 * Replaces the createApp(App) call when options are used (e.g. setup, provide, render)
 */
const app = createApp({
    setup() {
        provide(DefaultApolloClient, apolloClient)
    },
    render: () => h(App),
})

app.use(createPinia())
app.use(router)

app.mount('#app')
