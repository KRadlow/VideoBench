import { useState } from 'react';
import { Layout } from './pages/Layout';
import { Loader } from './components/Loader';
import './styles/App.css';

function App() {
  let [loading] = useState(false);

  if (loading) {
    return (
      <div className='App-layout'>
        <Loader />
      </div>
    );
  }

  return (
    <div className='App-layout'>
      <Layout />
    </div>
  );
}

export default App;
