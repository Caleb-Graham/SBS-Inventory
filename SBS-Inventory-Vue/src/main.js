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
import ConfirmDialog from 'primevue/confirmdialog';
import Toast from 'primevue/toast';
import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice';
import Card from 'primevue/card';
import Ripple from 'primevue/ripple';


// import CSS resources
import 'primevue/resources/primevue.min.css'            // core 
import 'primevue/resources/themes/saga-blue/theme.css'  // theme
import 'primeicons/primeicons.css';                     // icons
import router from './router'


const emitter = mitt();
const app = createApp(App).use(router);

app.config.globalProperties.emitter = emitter;

app.use(PrimeVue);
app.use(ConfirmationService);
app.use(ToastService);

app.directive('ripple', Ripple);


app.component('Button', Button);
app.component('Dialog', Dialog);
app.component('DataTable', DataTable);
app.component('Column', Column);
app.component('InputText', InputText);
app.component('Dropdown', Dropdown);
app.component('ConfirmDialog', ConfirmDialog);
app.component('Toast', Toast);
app.component('Card', Card);

app.mount('#app');
