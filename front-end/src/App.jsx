import deleteFoodItem from '../api/foodItems/deleteFoodItem';
import getFoodItems from '../api/foodItems/getFoodItems';
import './App.css'

export default function App() {
  return (
    <>
      <button
        onClick={async () => {
          deleteFoodItem(2).then(resp => console.log(resp));
        }}
      >
        Delete Item
      </button>

    </>
  );
}

