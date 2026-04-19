import matplotlib.pyplot as plt
import math
import collections

def load_file():
    file_name = input("Enter the file name (geoq.csv): ")

    data = {'X': [], 'Y': [], 'SiO2': [], 'Fe2O3': [], 'CaO': [], 'MgO': []}

    try:
        with open(file_name, 'r', encoding='utf-8') as file:
            file.readline().strip().split('\t')

            for line in file:
                values = line.strip().split('\t')
                x = float(values[0])
                y = float(values[1])
                sio2 = float(values[2])
                fe2o3 = float(values[3])
                cao = float(values[4])
                mgo = float(values[5])

                data['X'].append(x)
                data['Y'].append(y)
                data['SiO2'].append(sio2)
                data['Fe2O3'].append(fe2o3)
                data['CaO'].append(cao)
                if mgo != -99999:
                    data['MgO'].append(mgo)

            print("File loaded successfully!")
            return data

    except FileNotFoundError:
        print(f"File {file_name} not found.")
        return None

def basic_statistics(data, field):
    if field not in data:
        print(f"Invalid field {field}.")
        return

    values = data[field]

    if values:
        mean = sum(values) / len(values)

        print(f"\nStatistics for {field}:")
        print(f"Minimum: {min(values)}")
        print(f"Maximum: {max(values)}")
        print(f"Mean: {mean}")
    else:
        print(f"No data available for the field {field}.")

def scatter_plot(data, field_x, field_y):
    if field_x not in data or field_y not in data:
        print(f"Invalid fields {field_x} or {field_y}. Available fields: SiO2, Fe2O3, CaO, MgO")
        return

    values_x = data[field_x]
    values_y = data[field_y]

    plt.scatter(values_x, values_y)
    plt.title('Scatter Plot')
    plt.xlabel(f'{field_x} (%)')
    plt.ylabel(f'{field_y} (%)')
    plt.show()

def histogram(data, field, num_classes):
    if field not in data:
        print(f"Invalid field {field}. Available fields: SiO2, Fe2O3, CaO, MgO")
        return

    values = data[field]

    plt.hist(values, bins=num_classes, edgecolor='black')
    plt.title(f'Histogram of {field} compound (%) ({num_classes} classes)')
    plt.xlabel(f'{field} (%)')
    plt.ylabel('Absolute frequency')
    plt.show()

def granite_type_map(data):

    granite_I = {'x': [], 'y': []}
    granite_II = {'x': [], 'y': []}
    
    vx = data['X']
    vy = data['Y']
    cao = data['CaO']

    for i in range(len(cao)):

        if cao[i] < 2:
            granite_type = "Granite Type I"
        else:
            granite_type = "Granite Type II"
        
        if granite_type == "Granite Type I":
            granite_I['x'].append(vx[i])
            granite_I['y'].append(vy[i])
        elif granite_type == "Granite Type II":
            granite_II['x'].append(vx[i])
            granite_II['y'].append(vy[i])
    
    plt.scatter(granite_I['x'], granite_I['y'], color='blue', label='Granite Type I')
    plt.scatter(granite_II['x'], granite_II['y'], color='red', label='Granite Type II')

    plt.xlabel('X (Km)')
    plt.ylabel('Y (Km)')
    plt.title('Sampling Map')

    plt.legend()

    plt.show()

def calculate_distance(point1, point2):
    return math.sqrt((point2[0] - point1[0])**2 + (point2[1] - point1[1])**2)

def sampling_route(data):
    coordinates_x = []
    coordinates_y = []

    for sample in zip(data['X'], data['Y']):
        coordinates_x.append(sample[0])
        coordinates_y.append(sample[1])

    distances = [calculate_distance(p1, p2) for p1, p2 in zip(zip(data['X'], data['Y']), list(zip(data['X'], data['Y']))[1:])]
    total_distance = sum(distances)

    plt.plot(coordinates_x, coordinates_y, linestyle='--', label='Sampling Route')
    plt.scatter(coordinates_x, coordinates_y, color='blue', marker='o')
    plt.scatter(coordinates_x[0], coordinates_y[0], color='red', marker='^', label='Starting Point', s=100)
    plt.scatter(coordinates_x[-1], coordinates_y[-1], color='red', marker='s', label='End Point', s=100)
    plt.title('Sampling Route')
    plt.xlabel('X Coordinate')
    plt.ylabel('Y Coordinate')
    plt.legend()
    plt.grid(True)
    plt.show()

    print(f'Total Distance Covered: {total_distance:.2f} km')

def create_alternative_routes(data):
    starting_point = (data['X'][0], data['Y'][0])

    alternative_route_1 = [starting_point]
    remaining_points = list(zip(data['X'][1:], data['Y'][1:]))
    while remaining_points:
        current_point = alternative_route_1[-1]
        closest_point = min(remaining_points, key=lambda p: calculate_distance(current_point, p))
        alternative_route_1.append(closest_point)
        remaining_points.remove(closest_point)

    alternative_route_2 = [starting_point]
    remaining_points = list(zip(data['X'][1:], data['Y'][1:]))
    final_point = None
    while remaining_points:
        current_point = alternative_route_2[-1]
        closest_point = min(remaining_points, key=lambda p: calculate_distance(current_point, p))
        if final_point is None:
            final_point = closest_point
        else:
            alternative_route_2.append(closest_point)
        remaining_points.remove(closest_point)
    alternative_route_2.append(final_point)

    real_distance = calculate_total_distance(list(zip(data['X'], data['Y'])))
    alternative_distance_1 = calculate_total_distance(alternative_route_1)
    alternative_distance_2 = calculate_total_distance(alternative_route_2)

    plt.figure(figsize=(12, 7))

    plt.subplot(2, 2, 2)
    plt.title('Alternative 1')
    coords_alt_1 = list(zip(*alternative_route_1))
    plt.plot(coords_alt_1[0], coords_alt_1[1], marker='o', linestyle='-', color='green', label='Alternative 1')
    plt.legend()
    
    plt.subplot(2, 2, 4)
    plt.title('Alternative 2')
    coords_alt_2 = list(zip(*alternative_route_2))
    plt.plot(coords_alt_2[0], coords_alt_2[1], marker='s', linestyle='-', color='orange', label='Alternative 2')
    plt.legend()

    plt.subplot(1, 2, 1)
    real_route = list(zip(data['X'], data['Y']))
    coords_real = list(zip(*real_route))
    plt.plot(coords_real[0], coords_real[1], marker='^', linestyle='--', color='blue', label='Real Route')

    plt.xlabel('X Coordinate')
    plt.ylabel('Y Coordinate')
    plt.title('Real Route')
    plt.legend()
    plt.grid(True)
    plt.show()

    print(f"Real Route Distance: {real_distance:.2f}")
    print(f"Alternative 1 Distance: {alternative_distance_1:.2f}")
    print(f"Alternative 2 Distance: {alternative_distance_2:.2f}")

def calculate_total_distance(route):
    total_distance = 0
    for i in range(len(route) - 1):
        total_distance += calculate_distance(route[i], route[i + 1])
    return total_distance

def check_remove_duplicates(data):
    duplicates = [item for item, count in collections.Counter(list(zip(data['X'], data['Y']))).items() if count > 1]
    if not duplicates:
        print("No duplicate points found.")
        return

    print("Duplicate points found:")
    for duplicate_point in duplicates:
        print(f"Coordinates: {duplicate_point}")

    remove_duplicates = input("Do you want to remove the duplicate points? (Y/N): ").upper()

    if remove_duplicates == 'Y':
        data_without_duplicates = {'X': [], 'Y': [], 'SiO2': [], 'Fe2O3': [], 'CaO': [], 'MgO': []}

        for sample in data.values():
            coordinates = (sample[0], sample[1])
            if coordinates not in duplicates:
                data_without_duplicates['X'].append(sample[0])
                data_without_duplicates['Y'].append(sample[1])
                data_without_duplicates['SiO2'].append(sample[2])
                data_without_duplicates['Fe2O3'].append(sample[3])
                data_without_duplicates['CaO'].append(sample[4])
                data_without_duplicates['MgO'].append(sample[5])

        print("Duplicate points successfully removed.")
        return data_without_duplicates
    else:
        print("Duplicates were not removed.")
        return data

def main():
    data = None

    while True:
        print("\n=== Geochemical Data Analysis ===")
        print("1. Load geochemical data from file")
        print("2. Display basic statistics for an element")
        print("3. Create scatter plot")
        print("4. Create histogram")
        print("5. Generate granite type map")
        print("6. Generate sampling route")
        print("7. Generate alternative sampling routes")
        print("8. Check and remove duplicates")
        print("9. Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            data = load_file()
        elif choice == "2":
            if data:
                field = input("Enter the element (SiO2, Fe2O3, CaO, MgO): ")
                basic_statistics(data, field)
            else:
                print("Please load the data file first.")
        elif choice == "3":
            if data:
                field_x = input("Enter the X-axis element (SiO2, Fe2O3, CaO, MgO): ")
                field_y = input("Enter the Y-axis element (SiO2, Fe2O3, CaO, MgO): ")
                scatter_plot(data, field_x, field_y)
            else:
                print("Please load the data file first.")
        elif choice == "4":
            if data:
                field = input("Enter the element (SiO2, Fe2O3, CaO, MgO): ")
                num_classes = int(input("Enter the number of histogram classes: "))
                histogram(data, field, num_classes)
            else:
                print("Please load the data file first.")
        elif choice == "5":
            if data:
                granite_type_map(data)
            else:
                print("Please load the data file first.")
        elif choice == "6":
            if data:
                sampling_route(data)
            else:
                print("Please load the data file first.")
        elif choice == "7":
            if data:
                create_alternative_routes(data)
            else:
                print("Please load the data file first.")
        elif choice == "8":
            if data:
                data = check_remove_duplicates(data)
            else:
                print("Please load the data file first.")
        elif choice == "9":
            print("Exiting the program.")
            break
        else:
            print("Invalid option. Please try again.")

if __name__ == "__main__":
    main()
