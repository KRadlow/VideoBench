import { GridLoader } from 'react-spinners';

const style = {
  color: '#D16002'
}

export const Loader = () => {
  return (
    <GridLoader
      color={style.color}
      margin={'0 auto'}
      size={50}
      aria-label='Loading'
      data-testid='loader'
    />
  );
};