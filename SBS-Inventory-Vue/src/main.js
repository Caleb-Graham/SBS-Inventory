import { createApp } from 'vue';
import App from './App.vue';
import mitt from 'mitt'
import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import Dialog from 'primevue/dialog';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import InputText from 'primevue/inputtext';
import Dropdown from 'primevue/dropdown';


// import CSS resources
import 'primevue/resources/primevue.min.css'            // core 
import 'primevue/resources/themes/saga-blue/theme.css'  // theme
import 'primeicons/primeicons.css';                     // icons
import router from './router'

const emitter = mitt();
const app = createApp(App).use(router);

app.config.globalProperties.emitter = emitter;

app.use(PrimeVue);

app.component('Button', Button);
app.component('Dialog', Dialog);
app.component('DataTable', DataTable);
app.component('Column', Column);
app.component('InputText', InputText);
app.component('Dropdown', Dropdown);

app.mount('#app');
